using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkTheDog
{
   class Dog
   {
      public string DogName { get; set; }
      public double WalkTime { get; set; }
      public string BehaviorNotes { get; set; }
      public string FavoriteToy { get; set; }

      public void addWalkTime(double moreWalkTime)
      {
         WalkTime += moreWalkTime;
      }
   }
}
