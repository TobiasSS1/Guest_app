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
            ObservableCollection<Guest> test2 = new ObservableCollection<Guest>();
            int value = PersistencyService.LoadGuestsFromJsonAsync().Count;
            Assert.AreEqual(30, PersistencyService.LoadGuestsFromJsonAsync().Count);
        }
    }
}
