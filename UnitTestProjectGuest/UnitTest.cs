using System;
using Guest_app.Model;
using Guest_app.Persistency;

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Collections.ObjectModel;

namespace UnitTestProjectGuest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ObservableCollection<Guest> test = new ObservableCollection<Guest>();
         
            Assert.AreEqual(test,PersistencyService.LoadGuestsFromJsonAsync());
            Assert.
        }
    }
}
