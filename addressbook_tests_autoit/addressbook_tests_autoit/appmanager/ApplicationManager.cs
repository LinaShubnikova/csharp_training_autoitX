using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
	public class ApplicationManager
	{
		public static string WINTITLE = "Free Address Book";
		private AutoItX3 aux;
		private GroupHelper groupHelper;

		// конструктор инициализирует groupHelper
		public ApplicationManager()
		{
			aux = new AutoItX3();
			// запускаем тестируемую программу
			aux.Run(@"D:\FreeAddressBookPortable\AddressBook.exe", "", aux.SW_SHOW);
			// ЖДЕМ КОГДА ЗАГРУЗИТСЯ ГЛАВНОЕ ОКНО
			aux.WinWait(WINTITLE);
			aux.WinActivate(WINTITLE);
			aux.WinWaitActive(WINTITLE);

			groupHelper = new GroupHelper(this);
		}

		// останвливаем работу программы
		public void Stop()
		{
			aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
		}

		public AutoItX3 Aux
		{
			get
			{
				return aux;
			}
		}

		// метод класса GroupHelper, который возвращает объект groupHelper
		public GroupHelper Groups
		{
			get
			{
				return groupHelper;
			}
		}
	}
}
