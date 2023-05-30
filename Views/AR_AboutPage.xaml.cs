namespace AR_Apuntes.Views;

public partial class AR_AboutPage : ContentPage
{
	public AR_AboutPage()
	{
		InitializeComponent();
	}

    private async void AR_LearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.AR_About about)
        {
            // Navigate to the specified URL in the system browser.
            await Launcher.Default.OpenAsync(about.MoreInfoUrl);
        }
    }
}

