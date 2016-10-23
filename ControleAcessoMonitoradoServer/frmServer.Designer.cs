namespace ControleAcessoMonitoradoServer
{
    partial class frmServer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPortaServidor = new System.Windows.Forms.TextBox();
            this.btIniciarServidor = new System.Windows.Forms.Button();
            this.btPararServidor = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbIp = new System.Windows.Forms.ComboBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.cbNomeServidor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAutenticacao = new System.Windows.Forms.ComboBox();
            this.lbNomeUsuario = new System.Windows.Forms.Label();
            this.lbSenha = new System.Windows.Forms.Label();
            this.cbNomeUsuario = new System.Windows.Forms.ComboBox();
            this.tbSenha = new System.Windows.Forms.TextBox();
            this.btConectarBancoDados = new System.Windows.Forms.Button();
            this.btDesconectarBancoDados = new System.Windows.Forms.Button();
            this.lbStatusBancoDados = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP Servidor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Porta:";
            // 
            // tbPortaServidor
            // 
            this.tbPortaServidor.Location = new System.Drawing.Point(229, 19);
            this.tbPortaServidor.Name = "tbPortaServidor";
            this.tbPortaServidor.Size = new System.Drawing.Size(100, 20);
            this.tbPortaServidor.TabIndex = 3;
            // 
            // btIniciarServidor
            // 
            this.btIniciarServidor.Location = new System.Drawing.Point(345, 17);
            this.btIniciarServidor.Name = "btIniciarServidor";
            this.btIniciarServidor.Size = new System.Drawing.Size(75, 23);
            this.btIniciarServidor.TabIndex = 4;
            this.btIniciarServidor.Text = "Iniciar";
            this.btIniciarServidor.UseVisualStyleBackColor = true;
            this.btIniciarServidor.Click += new System.EventHandler(this.btIniciarServidor_Click);
            // 
            // btPararServidor
            // 
            this.btPararServidor.Location = new System.Drawing.Point(426, 17);
            this.btPararServidor.Name = "btPararServidor";
            this.btPararServidor.Size = new System.Drawing.Size(75, 23);
            this.btPararServidor.TabIndex = 5;
            this.btPararServidor.Text = "Parar";
            this.btPararServidor.UseVisualStyleBackColor = true;
            this.btPararServidor.Click += new System.EventHandler(this.btPararServidor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbIp);
            this.groupBox1.Controls.Add(this.lbStatus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbPortaServidor);
            this.groupBox1.Controls.Add(this.btPararServidor);
            this.groupBox1.Controls.Add(this.btIniciarServidor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(691, 52);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurações Servidor";
            // 
            // cbIp
            // 
            this.cbIp.FormattingEnabled = true;
            this.cbIp.Location = new System.Drawing.Point(82, 19);
            this.cbIp.Name = "cbIp";
            this.cbIp.Size = new System.Drawing.Size(100, 21);
            this.cbIp.TabIndex = 8;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(575, 22);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 13);
            this.lbStatus.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(518, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Status:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbStatusBancoDados);
            this.groupBox2.Controls.Add(this.btDesconectarBancoDados);
            this.groupBox2.Controls.Add(this.btConectarBancoDados);
            this.groupBox2.Controls.Add(this.tbSenha);
            this.groupBox2.Controls.Add(this.cbNomeUsuario);
            this.groupBox2.Controls.Add(this.lbSenha);
            this.groupBox2.Controls.Add(this.lbNomeUsuario);
            this.groupBox2.Controls.Add(this.cbAutenticacao);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbNomeServidor);
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(691, 141);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configurações Banco de Dados";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbConsole);
            this.groupBox3.Location = new System.Drawing.Point(12, 217);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(688, 394);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Console";
            // 
            // tbConsole
            // 
            this.tbConsole.Enabled = false;
            this.tbConsole.Location = new System.Drawing.Point(6, 19);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.Size = new System.Drawing.Size(676, 369);
            this.tbConsole.TabIndex = 1;
            // 
            // cbNomeServidor
            // 
            this.cbNomeServidor.FormattingEnabled = true;
            this.cbNomeServidor.Location = new System.Drawing.Point(116, 30);
            this.cbNomeServidor.Name = "cbNomeServidor";
            this.cbNomeServidor.Size = new System.Drawing.Size(213, 21);
            this.cbNomeServidor.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nome do servidor: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Autenticação:";
            // 
            // cbAutenticacao
            // 
            this.cbAutenticacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAutenticacao.FormattingEnabled = true;
            this.cbAutenticacao.Location = new System.Drawing.Point(116, 69);
            this.cbAutenticacao.Name = "cbAutenticacao";
            this.cbAutenticacao.Size = new System.Drawing.Size(213, 21);
            this.cbAutenticacao.TabIndex = 3;
            this.cbAutenticacao.SelectedValueChanged += new System.EventHandler(this.cbAutenticacao_SelectedValueChanged);
            // 
            // lbNomeUsuario
            // 
            this.lbNomeUsuario.AutoSize = true;
            this.lbNomeUsuario.Enabled = false;
            this.lbNomeUsuario.Location = new System.Drawing.Point(342, 33);
            this.lbNomeUsuario.Name = "lbNomeUsuario";
            this.lbNomeUsuario.Size = new System.Drawing.Size(92, 13);
            this.lbNomeUsuario.TabIndex = 4;
            this.lbNomeUsuario.Text = "Nome de Usuário:";
            // 
            // lbSenha
            // 
            this.lbSenha.AutoSize = true;
            this.lbSenha.Enabled = false;
            this.lbSenha.Location = new System.Drawing.Point(393, 72);
            this.lbSenha.Name = "lbSenha";
            this.lbSenha.Size = new System.Drawing.Size(41, 13);
            this.lbSenha.TabIndex = 5;
            this.lbSenha.Text = "Senha:";
            // 
            // cbNomeUsuario
            // 
            this.cbNomeUsuario.Enabled = false;
            this.cbNomeUsuario.FormattingEnabled = true;
            this.cbNomeUsuario.Location = new System.Drawing.Point(440, 30);
            this.cbNomeUsuario.Name = "cbNomeUsuario";
            this.cbNomeUsuario.Size = new System.Drawing.Size(192, 21);
            this.cbNomeUsuario.TabIndex = 6;
            // 
            // tbSenha
            // 
            this.tbSenha.Enabled = false;
            this.tbSenha.Location = new System.Drawing.Point(440, 69);
            this.tbSenha.Name = "tbSenha";
            this.tbSenha.Size = new System.Drawing.Size(192, 20);
            this.tbSenha.TabIndex = 7;
            // 
            // btConectarBancoDados
            // 
            this.btConectarBancoDados.Location = new System.Drawing.Point(116, 112);
            this.btConectarBancoDados.Name = "btConectarBancoDados";
            this.btConectarBancoDados.Size = new System.Drawing.Size(75, 23);
            this.btConectarBancoDados.TabIndex = 8;
            this.btConectarBancoDados.Text = "Conectar";
            this.btConectarBancoDados.UseVisualStyleBackColor = true;
            // 
            // btDesconectarBancoDados
            // 
            this.btDesconectarBancoDados.Location = new System.Drawing.Point(197, 112);
            this.btDesconectarBancoDados.Name = "btDesconectarBancoDados";
            this.btDesconectarBancoDados.Size = new System.Drawing.Size(82, 23);
            this.btDesconectarBancoDados.TabIndex = 9;
            this.btDesconectarBancoDados.Text = "Desconectar";
            this.btDesconectarBancoDados.UseVisualStyleBackColor = true;
            // 
            // lbStatusBancoDados
            // 
            this.lbStatusBancoDados.AutoSize = true;
            this.lbStatusBancoDados.Location = new System.Drawing.Point(393, 117);
            this.lbStatusBancoDados.Name = "lbStatusBancoDados";
            this.lbStatusBancoDados.Size = new System.Drawing.Size(40, 13);
            this.lbStatusBancoDados.TabIndex = 10;
            this.lbStatusBancoDados.Text = "Status:";
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 623);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmServer";
            this.Text = "Servidor";
            this.Load += new System.EventHandler(this.frmServer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPortaServidor;
        private System.Windows.Forms.Button btIniciarServidor;
        private System.Windows.Forms.Button btPararServidor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.ComboBox cbIp;
        private System.Windows.Forms.TextBox tbSenha;
        private System.Windows.Forms.ComboBox cbNomeUsuario;
        private System.Windows.Forms.Label lbSenha;
        private System.Windows.Forms.Label lbNomeUsuario;
        private System.Windows.Forms.ComboBox cbAutenticacao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbNomeServidor;
        private System.Windows.Forms.Button btDesconectarBancoDados;
        private System.Windows.Forms.Button btConectarBancoDados;
        private System.Windows.Forms.Label lbStatusBancoDados;
    }
}

