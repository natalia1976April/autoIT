using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            // if there is only one group we add second (due to one group can't be removed)
            if (app.Groups.GetGroupList().Count==1)
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "newGroupNN"
                };
                app.Groups.Add(newGroup);
            }
            
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData toRemove = app.Groups.GetGroupList()[0];
            app.Groups.Remove(toRemove);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(toRemove);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
