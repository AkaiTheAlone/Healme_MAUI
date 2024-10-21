namespace AplicativoMaiu.Views
{
    public partial class Sobre : ContentPage
    {
        public Sobre()
        {
            InitializeComponent();
        }
        public async void PrivacidadeView(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Privacidade());
        }
     
        public async void CVV(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://cvv.org.br/");
        }
        public async void SobreEmpresaView(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SobreEmpresa());
        }
    }
}

