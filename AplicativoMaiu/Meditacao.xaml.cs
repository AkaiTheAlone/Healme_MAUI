using System.Timers;

namespace AplicativoMaiu
{
    public partial class Meditacao : ContentPage
    {
        private System.Timers.Timer _temporizador;
        private TimeSpan _tempoRestante;
        private bool _isRunning;

        public Meditacao()
        {
            InitializeComponent();
            _temporizador = new System.Timers.Timer(1000);
            _temporizador.Elapsed += OnTemporizadorElapsed;
            _tempoRestante = TimeSpan.Zero;
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerTempo.SelectedIndex != -1)
            {
                int minutos = (int)pickerTempo.SelectedItem;
                _tempoRestante = TimeSpan.FromMinutes(minutos);
                lblCronometro.Text = _tempoRestante.ToString(@"mm\:ss");
            }
        }

        private void OnIniciarClicked(object sender, EventArgs e)
        {
            if (!_isRunning && _tempoRestante.TotalSeconds > 0)
            {
                _isRunning = true;
                _temporizador.Start();
            }
        }

        private void OnPararClicked(object sender, EventArgs e)
        {
            _isRunning = false;
            _temporizador.Stop();
        }

        private void OnReiniciarClicked(object sender, EventArgs e)
        {
            _temporizador.Stop();
            _isRunning = false;

            if (pickerTempo.SelectedIndex != -1)
            {
                int minutos = (int)pickerTempo.SelectedItem;
                _tempoRestante = TimeSpan.FromMinutes(minutos);
                lblCronometro.Text = _tempoRestante.ToString(@"mm\:ss");
            }
        }

        private void OnTemporizadorElapsed(object sender, ElapsedEventArgs e)
        {
            if (_tempoRestante.TotalSeconds > 0)
            {
                _tempoRestante = _tempoRestante.Add(TimeSpan.FromSeconds(-1));
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    lblCronometro.Text = _tempoRestante.ToString(@"mm\:ss");
                });
            }
            else
            {
                _temporizador.Stop();
                _isRunning = false;
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    lblCronometro.Text = "00:00";
                });
            }
        }
    }
}
