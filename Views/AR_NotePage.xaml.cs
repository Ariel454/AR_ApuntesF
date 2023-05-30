namespace AR_Apuntes.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class AR_NotePage : ContentPage
{
    //string AR_fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    public AR_NotePage()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        AR_CargarNota(Path.Combine(appDataPath, randomFileName));

    }

    private void AR_GuardarBoton_Clicked(object sender, EventArgs e) 
    {
        if (BindingContext is Models.AR_Note note)
            File.WriteAllText(note.Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    private void AR_BorrarBoton_Clicked(object sender, EventArgs e)
    {

        if (BindingContext is Models.AR_Note note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void AR_CargarNota(string AR_fileName)
    { 
        Models.AR_Note noteModel = new Models.AR_Note();
        noteModel.Filename = AR_fileName;

        if (File.Exists(AR_fileName))
        { 
            noteModel.Date = File.GetCreationTime(AR_fileName);
            noteModel.Text = File.ReadAllText(AR_fileName);
        }

        BindingContext = noteModel;
    }

    public string ItemId
    {
        set { AR_CargarNota(value); }
    }
}