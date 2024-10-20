using AplicativoMaiu.Views;

namespace AplicativoMaiu;

public partial class Sobre : ContentPage
{
	public Sobre()
	{
		InitializeComponent();
	}
	public async void PrivacidadeView(object sender, EventArgs e)
	{
		var PRIVPAGE = new Privacidade();
        await Navigation.PushAsync(new Privacidade());
    }
    public async void SobreNosView(object sender, EventArgs e)
    {
        //mudar essa bomba aq pra SobreNós
        var PRIVPAGE = new Privacidade();
        await Navigation.PushAsync(new Privacidade());
    }
    public async void CVV(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://cvv.org.br/");
    }
}