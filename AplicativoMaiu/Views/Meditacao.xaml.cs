using System.Timers;

namespace AplicativoMaiu
{
    public partial class Meditacao : ContentPage
    {
        private System.Timers.Timer _temporizador;
        private TimeSpan _tempoRestante;
        private bool _isRunning;
        private SpotifyService _spotifyService;

        public Meditacao()
        {
            InitializeComponent();
            _temporizador = new System.Timers.Timer(1000);
            _temporizador.Elapsed += TemporizadorTempo;
            _tempoRestante = TimeSpan.Zero;
            _spotifyService = new SpotifyService();
        }

        private void TempoSelecionado(object sender, EventArgs e)
        {
            if (pickerTempo.SelectedIndex != -1)
            {
                int minutos = (int)pickerTempo.SelectedItem;
                _tempoRestante = TimeSpan.FromMinutes(minutos);
                lblCronometro.Text = _tempoRestante.ToString(@"mm\:ss");
            }
        }

        private void IniciarTimer(object sender, EventArgs e)
        {
            if (!_isRunning && _tempoRestante.TotalSeconds > 0)
            {
                _isRunning = true;
                _temporizador.Start();
            }
        }

        private void PararTimer(object sender, EventArgs e)
        {
            _isRunning = false;
            _temporizador.Stop();
        }

        private void ReiniciarTimer(object sender, EventArgs e)
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

        private void TemporizadorTempo(object sender, ElapsedEventArgs e)
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

        private async void AbrirPlaylistSpotify(object sender, EventArgs e)
        {

            try
            {
                var isSpotifyInstalled = await Launcher.CanOpenAsync($"android-app://com.spotify.music");

                if (isSpotifyInstalled)
                {
                    await Launcher.OpenAsync("spotify:playlist:37i9dQZF1DWZYo1v54bwkI?si=d8fe94432cda463d");
                }
                else
                {
                    await Launcher.OpenAsync("https://open.spotify.com/playlist/37i9dQZF1DWZYo1v54bwkI?si=d8fe94432cda463d");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao abrir playlist: {ex.Message}");
            }
        }
    }
}
