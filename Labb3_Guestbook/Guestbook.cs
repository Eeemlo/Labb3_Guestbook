using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Labb3_Guestbook
{
    public class Guestbook
    {
        //variabel för att lagra fil för att lagra och läsa data
        private string filename = @"guestbook.json";
        //Lista för att lagra inlägg av typen Post
        private List<Post> posts = new List<Post>();


        //Konstruktor för klassen Guestbook
        public Guestbook()
        {
            if (File.Exists(filename) == true)
            {
                string jsonString = File.ReadAllText(filename);
                posts = JsonSerializer.Deserialize<List<Post>>(jsonString)!;
            }
        }

        //Metod för att lägga till inlägg
        public Post addPost (string name, string msg)
        {
            Post obj = new Post();
            obj.Name = name;
            obj.Message = msg;
            posts.Add(obj);
            marshal();
            return obj;
        }

        //Metod för att radera inlägg
        public int deletePost(int index)
        {
            posts.RemoveAt(index);
            marshal();
            return index;
        }
        //Metod för att hämta alla inlägg
        public List<Post> getPosts()
        {
            return posts;
        }


        //Privat metod för att spara inläggen till vår JSON-fil
        private void marshal()
        {
            var jsonString = JsonSerializer.Serialize(posts);
            File.WriteAllText(filename, jsonString);
        }
    }
}
