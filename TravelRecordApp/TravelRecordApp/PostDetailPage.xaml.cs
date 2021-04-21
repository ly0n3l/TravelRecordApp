using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailPage : ContentPage
    {
        Post selectedPost;

        public PostDetailPage()
        {
            InitializeComponent();
        }

        public PostDetailPage( Post selectedPost)
        {
            InitializeComponent();

            this.selectedPost = selectedPost;
            experienceEntry.Text = this.selectedPost.Experience;
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            this.selectedPost.Experience = experienceEntry.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedPost);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Your experience succesfully updated", "OK");
                }
                else
                {
                    DisplayAlert("Failure", "Your experience failed to be updated", "OK");
                }
            }
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Your experience succesfully deleted", "OK");
                }
                else
                {
                    DisplayAlert("Failure", "Your experience failed to be deleted", "OK");
                }
            }
        }
    }
}