using Timer = System.Windows.Forms.Timer;

namespace Clock_Widget
{
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        Timer saatTimer = new Timer();

        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X,
                    (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            saatTimer.Interval = 1000;
            saatTimer.Tick += SaatTimer_Tick;
            saatTimer.Start();
        }

        private void SaatTimer_Tick(object? sender, EventArgs e)
        {
            string saat = DateTime.Now.ToString("HH:mm");
            label1.Text = saat;
        }
    }
}
