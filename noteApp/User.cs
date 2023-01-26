using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace noteApp
{
    internal class User : Tools
    {
        private string username;
        private string password;

        private List<string> notes = new List<string>();

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            get { return username; }
        }

        public List<string> Notes
        {
            get { return notes; }
        }

        public bool PasswordMatch(string inputPassword)
        {
            return inputPassword == password;
        }

        public void ListNotes()
        {
            if (this.Notes.Count == 0)
            {
                Console.WriteLine("No notes yet...");
                return;
            }

            foreach (var n in this.Notes)
            {
                Console.WriteLine($"- {n}");
            }
        }

        public void removeNote()
        {
            if (this.notes.Count == 0)
            {
                Console.WriteLine("No notes...");
                Console.WriteLine("\nPress [ENTER] to return.");
                Console.ReadLine();
                Console.Clear();
                return;
            }

            for (int i = 0; i < this.notes.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {notes[i]}");
            }

            Console.Write("Enter the note's number to delete: ");
            string choice = Console.ReadLine();

            if (int.TryParse(choice, out int ch))
            {
                if (ch == 0 || ch > notes.Count + 1)
                {
                    Error("Invalid selection! Nothing was removed.");
                }

                notes.RemoveAt(ch - 1);
                Announcement($"Note #{ch} was removed!");
            }
            else
            {
                Error("Invalid selection! Nothing was removed.");
            }
        }
    }
}
