namespace AR_Apuntes.Views;

public partial class AR_AllNotesPage : ContentPage
{
	public AR_AllNotesPage()
	{
        InitializeComponent();

        BindingContext = new Models.AR_AllNotesPage();
    }

    protected override void OnAppearing()
    {
        ((Models.AllNotes)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AR_NotePage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.AR_Note)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(AR_NotePage)}?{nameof(AR_NotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}

