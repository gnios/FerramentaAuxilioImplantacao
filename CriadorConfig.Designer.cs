namespace FerramentaAuxilioImplantacao.App
{
	partial class CriadorConfig
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtXML = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.txtOrigem = new System.Windows.Forms.TextBox();
			this.txtDestino = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtChaveAplicacao = new System.Windows.Forms.TextBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// txtXML
			// 
			this.txtXML.Location = new System.Drawing.Point(12, 184);
			this.txtXML.Name = "txtXML";
			this.txtXML.Size = new System.Drawing.Size(510, 314);
			this.txtXML.TabIndex = 0;
			this.txtXML.Text = "";
			this.txtXML.TextChanged += new System.EventHandler(this.TxtXMLTextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 168);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "XML config";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(9, 516);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(763, 34);
			this.button1.TabIndex = 2;
			this.button1.Text = "Salvar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.SalvarClick);
			// 
			// flowPanel
			// 
			this.flowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowPanel.Location = new System.Drawing.Point(531, 184);
			this.flowPanel.Name = "flowPanel";
			this.flowPanel.Size = new System.Drawing.Size(241, 314);
			this.flowPanel.TabIndex = 3;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(631, 38);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(141, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "Abrir Arquivo Origem";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.AbrirArquivoOrigemClick);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(628, 85);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(141, 23);
			this.button3.TabIndex = 5;
			this.button3.Text = "Pasta para Salvar";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.EscolherPastaDestinoClick);
			// 
			// txtOrigem
			// 
			this.txtOrigem.Location = new System.Drawing.Point(9, 38);
			this.txtOrigem.Name = "txtOrigem";
			this.txtOrigem.Size = new System.Drawing.Size(616, 20);
			this.txtOrigem.TabIndex = 6;
			// 
			// txtDestino
			// 
			this.txtDestino.Location = new System.Drawing.Point(9, 87);
			this.txtDestino.Name = "txtDestino";
			this.txtDestino.Size = new System.Drawing.Size(616, 20);
			this.txtDestino.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(126, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Caminho Arquivo Destino";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(123, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Caminho Arquivo Origem";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(87, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Chave aplicação";
			// 
			// txtChaveAplicacao
			// 
			this.txtChaveAplicacao.Location = new System.Drawing.Point(9, 136);
			this.txtChaveAplicacao.Name = "txtChaveAplicacao";
			this.txtChaveAplicacao.Size = new System.Drawing.Size(231, 20);
			this.txtChaveAplicacao.TabIndex = 10;
			// 
			// CriadorConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtChaveAplicacao);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtDestino);
			this.Controls.Add(this.txtOrigem);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.flowPanel);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtXML);
			this.Name = "CriadorConfig";
			this.Text = "CriadorConfig";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox txtXML;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.FlowLayoutPanel flowPanel;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox txtOrigem;
		private System.Windows.Forms.TextBox txtDestino;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtChaveAplicacao;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
	}
}