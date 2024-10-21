namespace AplicativoMaiu;


public partial class Configuracoes : ContentPage
{
    public Configuracoes()
    {
        InitializeComponent();
    }

	

private void DesativarNotificacoes_Clicked(object sender, EventArgs e)
{
    // Cancela todas as notificações programadas

    // Exibe uma mensagem informando que as notificações foram desativadas
    DisplayAlert("Notificações", "Todas as notificações foram desativadas.", "OK");
}

}