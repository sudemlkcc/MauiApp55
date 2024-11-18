using System.Collections.ObjectModel;
using System.Text.Json;

namespace MauiApp5 {

    public partial class Görevler : ContentPage
    {
        private ObservableCollection<string> notes;
        private const string NotesFileName = "notes.json";

        public Görevler()
        {
            InitializeComponent();
            notes = LoadNotes();
            notesListView.ItemsSource = notes;
        }

        private void OnAddNoteClicked(object sender, EventArgs e)
        {
            string newNote = noteEntry.Text;
            if (!string.IsNullOrEmpty(newNote))
            {
                notes.Add(newNote);
                noteEntry.Text = string.Empty;
                SaveNotes();
                DisplayAlert("Not eklendi", $"Bu notu ekledin: {newNote}", "TAMAM");
            }
            else
            {
                DisplayAlert("Hata", "Lütfen not giriniz.", "TAMAM");
            }
        }

        private void OnEditNoteClicked(object sender, EventArgs e)
        {
            
        }

        private async void OnDeleteNoteClicked(object sender, EventArgs e)
        {
            bool deleteConfirmation = await DisplayAlert("Notu Sil", "Notu silmek istediğinden emin misin", "EVET", "HAYIR");

            if (deleteConfirmation)
            {
               
                SaveNotes();
            }
        }

        private void OnDeleteNotesClicked(object sender, EventArgs e)
        {
            notes.Clear();
            SaveNotes();
        }

        private void SaveNotes()
        {
            string json = JsonSerializer.Serialize(notes);
            File.WriteAllText(NotesFileName, json);

        }

        private ObservableCollection<string> LoadNotes()
        {
            try
            {
                if (File.Exists(NotesFileName))
                {
                    string json = File.ReadAllText(NotesFileName);
                    return JsonSerializer.Deserialize<ObservableCollection<string>>(json);
                }
            }
            catch (Exception ex)
            {
                
                DisplayAlert("Hata", $"Not yüklenirken hata oluştu: {ex.Message}", "TAMAM");
            }

            return new ObservableCollection<string>();
        }
    }
}
