namespace FerramentaAuxilioImplantacao.App
{
	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Windows.Forms;
	using System.Xml;
	using System.Xml.Serialization;

	public partial class CriadorConfig : Form
	{
		private string key = string.Empty;

		public CriadorConfig()
		{
			InitializeComponent();
			HighlightColors.HighlightRTF(txtXML);
			flowPanel.AutoScroll = true;
			flowPanel.WrapContents = false;
			flowPanel.Dock = DockStyle.None;
			flowPanel.AutoSize = false;
			flowPanel.FlowDirection = FlowDirection.TopDown;
		}

		private void TxtXMLTextChanged(object sender, EventArgs e)
		{
			HighlightColors.HighlightRTF(txtXML);

			Match match = Regex.Match(txtXML.Text, @"(?<!{){(?!{)([^}\n]*)}");
			var nomeControles = new List<string>();

			flowPanel.Controls.Clear();

			while (match.Success)
			{
				if (!nomeControles.Any(x => x == match.Value))
				{
					nomeControles.Add(match.Value);
				}
				match = match.NextMatch();
			}

			CriarInputs(nomeControles);
		}

		private void CriarInputs(IList<string> nomeControles)
		{
			foreach (var item in nomeControles)
			{
				Label label = CriarLabel(item);
				TextBox textbox = CriarTextBox(item);
				flowPanel.Controls.Add(label);
				flowPanel.Controls.Add(textbox);
			}
		}

		private static TextBox CriarTextBox(string item)
		{
			var textbox = new TextBox();
			textbox.Size = new Size(200, textbox.Size.Height);
			textbox.Name = item;
			if (item.Contains("|"))
			{
				var split = item.Split('|');
				textbox.Text = split[1].Replace("}", string.Empty);
			}

			return textbox;
		}

		private static Label CriarLabel(string item)
		{
			var label = new Label();

			string[] words = Regex.Matches(item, "(^[a-z]+|[A-Z]+(?![a-z])|[A-Z][a-z]+)").OfType<Match>().Select(m => m.Value).ToArray();
			string title = string.Join(" ", words);

			label.Text = title.Replace("}", string.Empty).Replace("}", string.Empty);
			label.Size = new Size(200, label.Size.Height);
			return label;
		}

		private void SalvarClick(object sender, EventArgs e)
		{
			string result = txtXML.Text;
			foreach (Control control in flowPanel.Controls)
			{
				if (control.GetType().Equals(typeof(TextBox)))
				{
					result = SubstituirChaves(result, control);
				}
			}

			var path = Path.Combine(txtDestino.Text, openFileDialog1.SafeFileName);
			if (File.Exists(path))
			{
				File.Delete(path);
			}

			using (FileStream fs = File.Create(path))
			{
				Byte[] info = new UTF8Encoding(true).GetBytes(result);
				fs.Write(info, 0, info.Length);
			}
		}

		private string SubstituirChaves(string result, Control control)
		{
			string textBoxName = control.Name;
			var textbox = ((TextBox)flowPanel.Controls[textBoxName]);

			string text = textbox.Text;

			if (textbox.Name.ToLower().Contains("senha") || textbox.Name.ToLower().Contains("login"))
			{
				var textoCriptografado = Criptografo.Criptografar(text, txtChaveAplicacao.Text);
				result = result.Replace(textbox.Name, textoCriptografado);
			}
			else
			{
				result = result.Replace(textbox.Name, textbox.Text);
			}

			return result;
		}

		private void AbrirArquivoOrigemClick(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{

				var config = DeserializarConfig(openFileDialog1.FileName);
				var chavePublica = config.AppSettings.Item.FirstOrDefault(x => x.Key == "ChavePublica");
				var chaveSecreta = config.AppSettings.Item.FirstOrDefault(x => x.Key == "ChaveSecreta");

				if (chaveSecreta != null && !string.IsNullOrEmpty(chaveSecreta.Value))
				{
					//Criptografo.AlterarChaveSecretaLocal(chaveSecreta.Value);
				}

				txtChaveAplicacao.Text = chavePublica?.Value ?? string.Empty;
				StreamReader stream = new StreamReader(openFileDialog1.FileName);
				txtOrigem.Text = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
				txtXML.Text = stream.ReadToEnd();
				stream.Close();
			}
		}

		private void EscolherPastaDestinoClick(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				txtDestino.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private ConfigurationModel DeserializarConfig(string fileName)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(ConfigurationModel));
			StreamReader stream = new StreamReader(fileName);
			XmlReader reader = XmlReader.Create(stream);
			ConfigurationModel item;
			item = (ConfigurationModel)serializer.Deserialize(reader);
			stream.Close();
			return item;
		}
	}
}
