﻿using System.Collections.Generic;

namespace ExtendedXmlSerializer.Tests.ReportedIssues.Shared.Issue517
{
	class ItemContainer
	{

		public List<Class1> Items { get; set; } = new List<Class1>();

	}

	class Class1
	{

		public Interface1 obj { get; set; }
	}

	interface Interface1 { }

	namespace ContainerNameSpace
	{
		class Container
		{
			public List<ItemNameSpace.Item> Childrens { get; set; } = new List<ItemNameSpace.Item>();
		}
	}

	namespace ItemNameSpace
	{
		class Item { }
	}

}
