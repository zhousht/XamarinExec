using HelloWorld.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactList : ContentPage
	{
        ObservableCollection<ContactGroup> contactGroup;
		public ContactList ()
		{
			InitializeComponent ();

            contactGroup = new ObservableCollection<ContactGroup>
            {
                new ContactGroup("S", "S")
                {
                    new Contact{Name="Sharon", ImageUrl="http://lorempixel.com/100/100/people/1", Status="Online"},
                    new Contact{Name="Simon", ImageUrl="http://lorempixel.com/100/100/people/3", Status="Let's chat"}

                },
                new ContactGroup("A","A"){
                    new Contact{Name="Anthony", ImageUrl="http://lorempixel.com/100/100/people/2", Status="Sleeping"}
                }
            };

            Contacts.ItemsSource = contactGroup;

        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;
            DisplayAlert("Call", contact.Name, "OK");
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            foreach(ContactGroup group in contactGroup)
            {
                group.Remove(contact);
            }
       }

        private void Contacts_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void Contacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //disable selected event
            Contacts.SelectedItem = null;
        }
    }
}