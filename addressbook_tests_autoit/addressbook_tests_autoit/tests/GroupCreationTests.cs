using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
	[TestFixture]
	public class GroupCreationTests : TestBase
	{
		[Test]
		public void TestGroupCreation()
		{
			// берем старый список групп
			List<GroupData> oldGroups = app.Groups.GetGroupList();

			// экземпляр групп
			GroupData newGroup = new GroupData()
			{
				Name = "test"
			};

			// создаем в программе новую группу
			app.Groups.Add(newGroup);

			// берем новый список групп
			List<GroupData> newGroups = app.Groups.GetGroupList();

			// добавляем созданную группу в старый список групп
			oldGroups.Add(newGroup);

			// сортируем списки
			oldGroups.Sort();
			newGroups.Sort();

			// сравниваем списки групп
			Assert.AreEqual(oldGroups, newGroups);

		}
	}
}
