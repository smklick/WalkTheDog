using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WalkTheDog
{
   public partial class WalkTheDogForm : Form
   {
      List<Account> accounts = new List<Account>();

      public WalkTheDogForm()
      {
         InitializeComponent();

         Account acct1 = new Account
         {
            Owner = new Owner
            {
               OwnerName = "Harry Heyboer",
               Address = new Address
               {
                  AddLine1 = "103 Baker St",
                  City = "Boston",
                  State = "MA",
                  Zip = "00897"
               },
               PhoneNumber = "999-122-3434"
            },

            Dogs = new List<Dog>()
         };

         Dog dog1 = new Dog
         {
            DogName = "Pork Chop",
            WalkTime = 15.0,
            FavoriteToy = "chew toy",
            BehaviorNotes = "Often good; hates cats."
         };

         acct1.Dogs.Add(dog1);
         accounts.Add(acct1);

         comboBoxAcctName.Items.Clear();
         comboBoxAcctName.Items.Add(new ComboBoxContents { Name = "New Account", Value = "0" });
         for (var i = 0; i < accounts.Count; i++)
         {
            comboBoxAcctName.Items.Add(new ComboBoxContents{ Name = Convert.ToString(accounts[i].Owner.OwnerName), Value = Convert.ToString(i) });
         }
         comboBoxAcctName.ValueMember = "value";
         comboBoxAcctName.DisplayMember = "name";
      }

      private void label5_Click(object sender, EventArgs e)
      {

      }

      private void buttonAdd_Click(object sender, EventArgs e)
      {
         Account acct = new Account()
         {
            Owner = new Owner
            {
               OwnerName = textBoxOwnerName.Text,
               Address = new Address
               {
                  AddLine1 = textBoxStreetAddress.Text,
                  City = textBoxCity.Text,
                  State = textBoxState.Text,
                  Zip = textBoxZip.Text
               },
            },

            Dogs = new List<Dog>()
         };

         Dog dog1 = new Dog
         {
            DogName = textBoxDogName.Text,
            WalkTime = Convert.ToDouble(textBoxTotalTime.Text),
            FavoriteToy = textBoxFavoriteToy.Text,
            BehaviorNotes = textBoxBehaviorNotes.Text
         };

         acct.Dogs.Add(dog1);
         accounts.Add(acct);

         MessageBox.Show($"{dog1.DogName} has been added!\n" +
                $"Owner: {acct.Owner.OwnerName} " +
                $"\nOwner Address: {acct.Owner.Address.AddLine1}\n\t" +
                $"  {acct.Owner.Address.AddLine2}" +
                $"  {acct.Owner.Address.AddLine3}" +
                $"         {acct.Owner.Address.City}, {acct.Owner.Address.State}  {acct.Owner.Address.Zip} \n" +
                $"Dog(s): {dog1.DogName} " +
                $"\nWalk Time: {dog1.WalkTime} " +
                $"\nFavorite Toy: {dog1.FavoriteToy} " +
                $"\nBehavior Notes: {dog1.BehaviorNotes}", "Congratulations!", MessageBoxButtons.OK);

      }

      private void comboBoxAcctName_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (comboBoxAcctName.SelectedIndex.Equals(0))
         {
            textBoxOwnerName.Clear();
            textBoxDogName.Clear();
            textBoxStreetAddress.Clear();
            textBoxCity.Clear();
            textBoxState.Clear();
            textBoxZip.Clear();
            textBoxBehaviorNotes.Clear();
            textBoxTotalTime.Clear();
            textBoxFavoriteToy.Clear();
         }
         else
         {
            var index = comboBoxAcctName.SelectedIndex - 1;
            textBoxOwnerName.Text = accounts[index].Owner.OwnerName;
            textBoxDogName.Text = accounts[index].Dogs[0].DogName;
            textBoxStreetAddress.Text = accounts[index].Owner.Address.AddLine1;
            textBoxCity.Text = accounts[index].Owner.Address.City;
            textBoxState.Text = accounts[index].Owner.Address.State;
            textBoxZip.Text = accounts[index].Owner.Address.Zip;
            textBoxBehaviorNotes.Text = accounts[index].Dogs[0].BehaviorNotes;
            textBoxTotalTime.Text = Convert.ToString(accounts[index].Dogs[0].WalkTime);
            textBoxFavoriteToy.Text = accounts[index].Dogs[0].FavoriteToy;
         }

      }
   }
}
