using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AR_Apuntes.Models;

internal class AR_AllNotes
{
    public ObservableCollection<AR_Note> Notes { get; set; } = new ObservableCollection<AR_Note>();

    public AR_AllNotes() =>
        LoadNotes();

    public void LoadNotes()
    {
        Notes.Clear();

        // Get the folder where the notes are stored.
        string appDataPath = FileSystem.AppDataDirectory;

        // Use Linq extensions to load the *.notes.txt files.
        IEnumerable<AR_Note> notes = Directory

                                    // Select the file names from the directory
                                    .EnumerateFiles(appDataPath, "*.notes.txt")

                                    // Each file name is used to create a new Note
                                    .Select(filename => new AR_Note()
                                    {
                                        Filename = filename,
                                        Text = File.ReadAllText(filename),
                                        Date = File.GetCreationTime(filename)
                                    })

                                    // With the final collection of notes, order them by date
                                    .OrderBy(note => note.Date);

        // Add each note into the ObservableCollection
        foreach (AR_Note note in notes)
            Notes.Add(note);
    }
}