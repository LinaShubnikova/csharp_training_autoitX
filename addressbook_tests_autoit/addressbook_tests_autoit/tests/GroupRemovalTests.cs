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
			// берем старый список групп
			List<GroupData> oldGroups = app.Groups.GetGroupList();

			// задаем индекс группы для удаления
			const int selectGroupRemove = 2;

			// удаляем группу
			app.Groups.RemoveGroup(selectGroupRemove);

			// берем новый список групп
			List<GroupData> newGroups = app.Groups.GetGroupList();

			// удалеям из старого списка удаленную группу
			oldGroups.RemoveAt(selectGroupRemove);

			// сортируем списки
			oldGroups.Sort();
			newGroups.Sort();

			// сравниваем списки групп
			Assert.AreEqual(oldGroups, newGroups);

		}
		
	}
}
