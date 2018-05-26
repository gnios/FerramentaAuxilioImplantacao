namespace FerramentaAuxilioImplantacao.App
{
	using System;
	using System.Configuration;
	using System.IO;
	using System.Security.Cryptography;
	using System.Text;

	public static class Criptografo
	{
		private static byte[] ChaveSecreta = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["ChaveSecreta"]);

		public static void AlterarChaveSecretaLocal(string novaChave)
		{
			ChaveSecreta = Encoding.ASCII.GetBytes(novaChave);
		}

		/// <summary>Criptografar o Texto.</summary>
		/// <param name="textoLimpo">Texto Limpo para criptografar</param>
		/// <param name="chaveAplicacao">A Chave secreta da aplicação </param>
		/// <returns>The <see cref="string"/>.</returns>
		public static string Criptografar(string textoLimpo, string chaveAplicacao)
		{

			if (string.IsNullOrEmpty(textoLimpo))
			{
				throw new ArgumentNullException(nameof(textoLimpo));
			}

			if (string.IsNullOrEmpty(chaveAplicacao))
			{
				throw new ArgumentNullException(nameof(chaveAplicacao));
			}

			string outStr = null;
			RijndaelManaged aesAlg = null;

			try
			{
				var key = new Rfc2898DeriveBytes(chaveAplicacao, ChaveSecreta);

				aesAlg = new RijndaelManaged();
				aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);

				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

				var memoryStream = new MemoryStream();

				memoryStream.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
				memoryStream.Write(aesAlg.IV, 0, aesAlg.IV.Length);
				var encrypt = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

				using (var streamWriter = new StreamWriter(encrypt))
				{
					streamWriter.Write(textoLimpo);
				}

				outStr = Convert.ToBase64String(memoryStream.ToArray());
			}
			catch (Exception ex)
			{
				throw new CryptographicException("Erro ao descriptografar", ex);
			}
			finally
			{
				aesAlg?.Clear();
			}

			return outStr;
		}

		/// <summary>Descriptografar o texto.</summary>
		/// <param name="textoCriptografado">Texto criptografado (espera-se que achave usada para cripgrafar seja a mesma da envida pelo parametro)</param>
		/// <param name="chavePublicaAplicacao">Chave secreta da aplicação</param>
		/// <exception cref="FormatException">Formato invalido.</exception>
		/// <returns>The <see cref="string"/> Texto criprgafado.</returns>
		public static string Descriptografar(string textoCriptografado, string chavePublicaAplicacao)
		{
			if (string.IsNullOrEmpty(textoCriptografado))
			{
				throw new ArgumentNullException(nameof(textoCriptografado));
			}

			if (string.IsNullOrEmpty(chavePublicaAplicacao))
			{
				throw new ArgumentNullException(nameof(chavePublicaAplicacao));
			}

			string plaintext = null;
			RijndaelManaged rijndaelManaged = null;
			try
			{
				using (var key = new Rfc2898DeriveBytes(chavePublicaAplicacao, ChaveSecreta))
				{
					byte[] bytes = Convert.FromBase64String(textoCriptografado);
					using (var decrypt = new MemoryStream(bytes))
					{
						rijndaelManaged = new RijndaelManaged();
						rijndaelManaged.Key = key.GetBytes(rijndaelManaged.KeySize / 8);
						rijndaelManaged.IV = ReadByteArray(decrypt);
						ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(
							rijndaelManaged.Key,
							rijndaelManaged.IV);
						var cryptoStream = new CryptoStream(decrypt, decryptor, CryptoStreamMode.Read);
						var streamReader = new StreamReader(cryptoStream);
						plaintext = streamReader.ReadToEnd();
					}
				}
			}
			catch (Exception ex)
			{
				throw new CryptographicException("Erro ao descriptografar", ex);
			}
			finally
			{
				rijndaelManaged?.Dispose();
			}

			return plaintext;
		}

		private static byte[] ReadByteArray(Stream stream)
		{
			var rawLength = new byte[sizeof(int)];
			if (stream.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
			{
				throw new EndOfStreamException("Stream did not contain properly formatted byte array");
			}

			var buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
			if (stream.Read(buffer, 0, buffer.Length) != buffer.Length)
			{
				throw new EndOfStreamException("Did not read byte array properly");
			}

			return buffer;
		}
	}
}