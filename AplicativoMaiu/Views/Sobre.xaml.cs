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
}