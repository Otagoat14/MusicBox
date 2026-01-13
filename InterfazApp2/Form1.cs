using System;
using System.Drawing;
using System.Windows.Forms;
using MusicBox.core;

namespace InterfazApp2
{
    public partial class Form1 : Form
    {
        private ComboBox cbNotas;
        private ComboBox cbFiguras;
        private TextBox txtValorNegra;
        private Button btnInsertar;
        private Button btnPlay;
        private Button btnPlayReversa;
        private ListBox lstNotas;
        private Label lblNotas;
        private Label lblFiguras;
        private Label lblValor;
        private Lista_Doble_MusicBox lista = new Lista_Doble_MusicBox();

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(500, 450);
            this.Name = "Form1";
            this.Text = "MusicBox";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        private void InitializeCustomComponents()
        {
            MessageBox.Show("UI inicializada");

            lblNotas = new Label();
            lblNotas.Text = "Nota:";
            lblNotas.Location = new Point(30, 30);
            lblNotas.AutoSize = true;

            cbNotas = new ComboBox();
            cbNotas.Location = new Point(150, 30);
            cbNotas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNotas.Items.AddRange(new string[]
            {
                "Do", "Re", "Mi", "Fa", "Sol", "La", "Si"
            });

            lblFiguras = new Label();
            lblFiguras.Text = "Figura:";
            lblFiguras.Location = new Point(30, 70);
            lblFiguras.AutoSize = true;

            cbFiguras = new ComboBox();
            cbFiguras.Location = new Point(150, 70);
            cbFiguras.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFiguras.Items.AddRange(new string[]
            {
                "Negra", "Corchea", "Semicorchea", "Blanca", "Redonda"
            });

            lblValor = new Label();
            lblValor.Text = "Valor de la negra:";
            lblValor.Location = new Point(30, 110);
            lblValor.AutoSize = true;

            txtValorNegra = new TextBox();
            txtValorNegra.Location = new Point(150, 110);

            btnInsertar = new Button();
            btnInsertar.Text = "Insertar";
            btnInsertar.Location = new Point(150, 150);
            btnInsertar.Click += BtnInsertar_Click;

            lstNotas = new ListBox();
            lstNotas.Location = new Point(30, 200);
            lstNotas.Size = new Size(400, 100);

            btnPlay = new Button();
            btnPlay.Text = "Play";
            btnPlay.Location = new Point(30, 320);
            btnPlay.Click += BtnPlay_Click;

            btnPlayReversa = new Button();
            btnPlayReversa.Text = "Play Reversa";
            btnPlayReversa.Location = new Point(150, 320);
            btnPlayReversa.Click += BtnPlayReversa_Click;

            this.Controls.Add(lblNotas);
            this.Controls.Add(cbNotas);
            this.Controls.Add(lblFiguras);
            this.Controls.Add(cbFiguras);
            this.Controls.Add(lblValor);
            this.Controls.Add(txtValorNegra);
            this.Controls.Add(btnInsertar);
            this.Controls.Add(lstNotas);
            this.Controls.Add(btnPlay);
            this.Controls.Add(btnPlayReversa);
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            if (cbNotas.SelectedItem == null || cbFiguras.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una nota y una figura");
                return;
            }

            string nota = cbNotas.SelectedItem.ToString();
            string figura = cbFiguras.SelectedItem.ToString();

            lista.insertar_partitura((nota, figura));
            lstNotas.Items.Add($"{nota} - {figura}");
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            lista.reproducir_partitura();
        }

        private void BtnPlayReversa_Click(object sender, EventArgs e)
        {
            // Implementar reproducción reversa
            MessageBox.Show("Play Reversa - Por implementar");
        }
    }
}