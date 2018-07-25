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


   }
}
