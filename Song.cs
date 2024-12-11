using System;

namespace DZ7
{
    internal class Song
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public Song Prev { get; set; }

        public Song(string name, string author, Song prev = null)
        {
            Name = name;
            Author = author;
            Prev = prev;
        }

        public string Title()
        {
            return $"{Name} by {Author}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Song otherSong)
            {
                return Name == otherSong.Name && Author == otherSong.Author;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + (Name?.GetHashCode() ?? 0);
            hash = hash * 23 + (Author?.GetHashCode() ?? 0);
            return hash;
        }
    }
}
