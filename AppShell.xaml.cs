namespace AR_Apuntes;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(Views.AR_NotePage), typeof(Views.AR_NotePage));
    }
}
