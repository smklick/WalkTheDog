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

         buttonTodayTime.Enabled = false;

         Account acct1 = new Account
         {
            Owner = new Owner
            {
               OwnerName = "Sarah Klick",
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

         comboBoxState.Items.Add(new List<State>());
      }

      private void buttonAdd_Click(object sender, EventArgs e)
      {
         if (!double.TryParse(textBoxTotalTime.Text, out double totalTime))
         {
            totalTime = 0;
         }

         Account acct = new Account()
         {
            Owner = new Owner
            {
               OwnerName = textBoxOwnerName.Text,
               Address = new Address
               {
                  AddLine1 = textBoxStreetAddress.Text,
                  City = textBoxCity.Text,
                  State = comboBoxState.SelectedText,
                  Zip = textBoxZip.Text
               },
            },

            Dogs = new List<Dog>()
         };

         Dog dog1 = new Dog
         {
            DogName = textBoxDogName.Text,
            WalkTime = totalTime,
            FavoriteToy = textBoxFavoriteToy.Text,
            BehaviorNotes = textBoxBehaviorNotes.Text
         };

         acct.Dogs.Add(dog1);
         accounts.Add(acct);

         MessageBox.Show($"An account for {dog1.DogName} has been added!", "Congratulations!", MessageBoxButtons.OK);

         comboBoxAcctName.Items.Clear();
         comboBoxAcctName.Items.Add(new ComboBoxContents { Name = "New Account", Value = "0" });
         for (var i = 0; i < accounts.Count; i++)
         {
            comboBoxAcctName.Items.Add(new ComboBoxContents { Name = Convert.ToString(accounts[i].Owner.OwnerName), Value = Convert.ToString(i) });
         }
         comboBoxAcctName.ValueMember = "value";
         comboBoxAcctName.DisplayMember = "name";

         clearTextBox();

      }

      private void comboBoxAcctName_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (comboBoxAcctName.SelectedIndex.Equals(0))
         {
            clearTextBox();

            buttonAdd.Enabled = true;
            buttonTodayTime.Enabled = false;
         }
         else
         {
            var index = comboBoxAcctName.SelectedIndex - 1;
            textBoxOwnerName.Text = accounts[index].Owner.OwnerName;
            textBoxDogName.Text = accounts[index].Dogs[0].DogName;
            textBoxStreetAddress.Text = accounts[index].Owner.Address.AddLine1;
            textBoxCity.Text = accounts[index].Owner.Address.City;
            comboBoxState.Text = accounts[index].Owner.Address.State;
            textBoxZip.Text = accounts[index].Owner.Address.Zip;
            textBoxBehaviorNotes.Text = accounts[index].Dogs[0].BehaviorNotes;
            textBoxTotalTime.Text = Convert.ToString(accounts[index].Dogs[0].WalkTime);
            textBoxFavoriteToy.Text = accounts[index].Dogs[0].FavoriteToy;

            buttonAdd.Enabled = false;
            buttonTodayTime.Enabled = true;
         }

      }

      private void buttonTodayTime_Click(object sender, EventArgs e)
      {
         var index = comboBoxAcctName.SelectedIndex - 1;

         if (double.TryParse(textBoxTodayTime.Text, out double todayTime))
         {
            accounts[index].Dogs[0].addWalkTime(todayTime);
            textBoxTodayTime.Clear();
            textBoxTotalTime.Clear();
            textBoxTotalTime.Text = Convert.ToString(accounts[index].Dogs[0].WalkTime);
         }
         else
         {
            MessageBox.Show("Please enter a valid time");
         }
      }

      private void buttonReport_Click(object sender, EventArgs e)
      {
         labelReport.Text = String.Empty;

         var dogReport =
            from a in accounts
            where a.Dogs[0].DogName == textBoxDogName.Text
            select new { oName = a.Owner.OwnerName, dName = a.Dogs[0].DogName, time = a.Dogs[0].WalkTime };

         foreach ( var element in dogReport)
         {
            labelReport.Text = $"Owner Name:          {element.oName}\n" +
               $"Dog Name:               {element.dName}\n" +
               $"Total Time Walked:  {element.time} minutes";
         }
      }

      private void buttonTotalTimeRepor_Click(object sender, EventArgs e)
      {
         labelReport.Text = String.Empty;
         var sum = 0.0;

         var totalReport =
            from a in accounts
            orderby a.Dogs[0].DogName ascending
            select new { dName = a.Dogs[0].DogName, time = a.Dogs[0].WalkTime };

         foreach (var element in totalReport)
         {
            labelReport.Text += $"{element.dName}:  {element.time} minutes\n";
            sum += element.time;
         }

         labelReport.Text += $"\n\n\n\nTotal time: {sum} minutes";
      }

      private void clearTextBox()
      {
         textBoxOwnerName.Clear();
         textBoxDogName.Clear();
         textBoxStreetAddress.Clear();
         textBoxCity.Clear();
         textBoxZip.Clear();
         textBoxBehaviorNotes.Clear();
         textBoxTotalTime.Clear();
         textBoxFavoriteToy.Clear();
      }

      private void comboBoxState_SelectedIndexChanged(object sender, EventArgs e)
      {

      }
   }
}
