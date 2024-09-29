namespace AplicativoMaiu
{
    public partial class App : Application
    {
        public App()
        {
     
            InitializeComponent();
            AppTheme currentTheme = Application.Current.RequestedTheme;
            MainPage = new AppShell();
        }
    }
}
