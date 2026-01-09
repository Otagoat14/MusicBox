using System;
using System.Drawing;
using System.Windows.Forms;

namespace InterfazApp
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

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "MusicBox";
            this.Size = new Size(500, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblNotas = new Label();
            lblNotas.Text = "Nota:";
            lblNotas.Location = new Point(30, 30);

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

            btnPlayReversa = new Button();
            btnPlayReversa.Text = "Play Reversa";
            btnPlayReversa.Location = new Point(150, 320);

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

        // Esto solo es visual para ver que la interfaz funcionara
        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            if (cbNotas.SelectedItem == null || cbFiguras.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una nota y una figura");
                return;
            }

            string nota = cbNotas.SelectedItem.ToString();
            string figura = cbFiguras.SelectedItem.ToString();

            lstNotas.Items.Add($"{nota} - {figura}");
        }
    }
}
