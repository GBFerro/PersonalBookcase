﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookcase
{
    internal class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public string? Description { get; set; }
        public Author Author { get; set; }
        public string? Publisher { get; set; }

        public Book(string? title, string? isbn)
        {
            this.Title = title;
            this.ISBN = isbn;
            this.Description = string.Empty;
            this.Publisher = string.Empty;
        }

        public void AddAuthor(Author author)
        {
            //List<Author> list = new List<Author>();

            this.Author = author;
        }

        public Book(string title, string iSBN, string description, string publisher) : this(title, iSBN)
        {
            Description = description;
            Publisher = publisher;
        }

        public override string ToString()
        {
            return $"{this.Title} | {this.Description} | {this.ISBN} | {this.Author.Name} | {this.Author.BirthYear} | {this.Publisher}";
        }
    }
}
