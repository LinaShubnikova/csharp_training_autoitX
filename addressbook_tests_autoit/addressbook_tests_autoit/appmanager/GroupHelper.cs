using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
	public class GroupHelper : HelperBase
	{
		public static string GROUPWINTITLE = "Group editor";
		public static string GROUPWINDELETE = "Delete group";

		public GroupHelper(ApplicationManager manager) : base(manager)
		{

		}

		// метод получения списка групп
		public List<GroupData> GetGroupList()
		{
			List<GroupData> list = new List<GroupData>();
			OpenGroupsDialogue();
			// берем список групп
			string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
				"GetItemCount", "#0", "");
			// счетчик количества групп
			for (int i=0; i <  int.Parse(count); i++)
			{
				// берем имя каждой группы
				string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
				"GetText", "#0|#"+i, "");
				// добавляем имена групп с список list
				list.Add(new GroupData()
				{
					Name = item
				});
			}
			CloseGroupsDialogue();
			return list;
			//return new List<GroupData>();
		}

		public void RemoveGroup(int selectGroupRemove)
		{
			OpenGroupsDialogue();
			// выбираем группу для удаления
			aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "RIGHT", selectGroupRemove);
			aux.Send("{RIGHT}");
			// нажимаем удалить группу
			aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
			// ждем когда окно Delete group ПОЯВИТСЯ
			aux.WinWait(GROUPWINDELETE);
			// нажимаем интер
			aux.Send("{ENTER}");
			// закрываем окно
			CloseGroupsDialogue();
		}

		// метод создания гуппы
		public void Add(GroupData newGroup)
		{
			OpenGroupsDialogue();
			// нажимаем кнопку NEW
			aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
			// вписываем название группы
			aux.Send(newGroup.Name);
			// нажимаем интер
			aux.Send("{ENTER}");
			CloseGroupsDialogue();
		}

		// метод закрывает окно добавления групп
		private void CloseGroupsDialogue()
		{
			// нажимаем кнопку SEND
			aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
		}

		// метод окрытия окна с группами
		private void OpenGroupsDialogue()
		{
			// открываем окно добавления групп
			aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
			// ждем когда окно GROUP EDITOR ПОЯВИТСЯ
			aux.WinWait(GROUPWINTITLE);
		}
	}
}