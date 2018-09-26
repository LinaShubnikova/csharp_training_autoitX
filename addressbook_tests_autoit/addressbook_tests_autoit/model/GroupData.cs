using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
	// наследование сравнения элементов типа GroupData
	public class GroupData : IComparable<GroupData>, IEquatable<GroupData>
	{
		public string Name { get; set; }

		// метод сортировки списков
		public int CompareTo(GroupData other)
		{
			// возвращаем результат сортировки
			return this.Name.CompareTo(other.Name);
		}

		// метод сравнения элементов
		public bool Equals(GroupData other)
		{
			// возвращаем результат сравнения
			return this.Name.Equals(other.Name);
		}
	}
}
