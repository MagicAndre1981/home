﻿using ExtendedXmlSerializer.Configuration;
using ExtendedXmlSerializer.Tests.ReportedIssues.Support;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;
// ReSharper disable All

namespace ExtendedXmlSerializer.Tests.ReportedIssues
{
	public sealed class Issue485Tests
	{
		[Fact]
		public void Verify()
		{
			var instance = new[] { 1, 2, 3, 4 }.ToImmutableList();

			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContent()
			                                             .Create()
			                                             .ForTesting();
			serializer.Assert(instance,
			                  @"<?xml version=""1.0"" encoding=""utf-8""?><ImmutableList xmlns:sys=""https://extendedxmlserializer.github.io/system"" xmlns:exs=""https://extendedxmlserializer.github.io/v2"" exs:arguments=""sys:int"" xmlns=""clr-namespace:System.Collections.Immutable;assembly=System.Collections.Immutable""><sys:int>1</sys:int><sys:int>2</sys:int><sys:int>3</sys:int><sys:int>4</sys:int></ImmutableList>");
			serializer.Cycle(instance).Should().BeEquivalentTo(instance);
		}

		[Fact]
		public void VerifyHashSet()
		{
			var instance = new[] { 1, 2, 3, 4 }.ToImmutableHashSet();

			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContent()
			                                             .Create()
			                                             .ForTesting();
			serializer.Assert(instance,
			                  @"<?xml version=""1.0"" encoding=""utf-8""?><ImmutableHashSet xmlns:sys=""https://extendedxmlserializer.github.io/system"" xmlns:exs=""https://extendedxmlserializer.github.io/v2"" exs:arguments=""sys:int"" xmlns=""clr-namespace:System.Collections.Immutable;assembly=System.Collections.Immutable""><sys:int>1</sys:int><sys:int>2</sys:int><sys:int>3</sys:int><sys:int>4</sys:int></ImmutableHashSet>");
			serializer.Cycle(instance).Should().BeEquivalentTo(instance);
		}

		[Fact]
		public void VerifySortedSet()
		{
			var instance = new[] { 1, 2, 3, 4 }.ToImmutableSortedSet();

			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContent()
			                                             .Create()
			                                             .ForTesting();
			serializer.Assert(instance,
			                  @"<?xml version=""1.0"" encoding=""utf-8""?><ImmutableSortedSet xmlns:sys=""https://extendedxmlserializer.github.io/system"" xmlns:exs=""https://extendedxmlserializer.github.io/v2"" exs:arguments=""sys:int"" xmlns=""clr-namespace:System.Collections.Immutable;assembly=System.Collections.Immutable""><sys:int>1</sys:int><sys:int>2</sys:int><sys:int>3</sys:int><sys:int>4</sys:int></ImmutableSortedSet>");
			serializer.Cycle(instance).Should().BeEquivalentTo(instance);
		}

		[Fact]
		public void VerifyDictionary()
		{
			var instance = new Dictionary<string, string>
			{
				["Hello"] = "World"
			}.ToImmutableDictionary();

			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContent()
			                                             .Create()
			                                             .ForTesting();

			serializer.Assert(instance,
			                  @"<?xml version=""1.0"" encoding=""utf-8""?><ImmutableDictionary xmlns:sys=""https://extendedxmlserializer.github.io/system"" xmlns:exs=""https://extendedxmlserializer.github.io/v2"" exs:arguments=""sys:string,sys:string"" xmlns=""clr-namespace:System.Collections.Immutable;assembly=System.Collections.Immutable""><sys:Item Key=""Hello"" Value=""World"" /></ImmutableDictionary>");

			var dictionary = serializer.Cycle(instance);
			dictionary.Should().BeEquivalentTo(instance);

			dictionary["Hello"].Should().Be(instance["Hello"]);
		}

		[Fact]
		public void VerifySortedDictionary()
		{
			var instance = new Dictionary<string, string>
			{
				["First"]  = "Value1",
				["Hello"]  = "World",
				["Second"] = "Value2",
				["Last"]   = "Value2",
			}.ToImmutableSortedDictionary();

			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContent()
			                                             .Create()
			                                             .ForTesting();

			serializer.Assert(instance,
			                  @"<?xml version=""1.0"" encoding=""utf-8""?><ImmutableSortedDictionary xmlns:sys=""https://extendedxmlserializer.github.io/system"" xmlns:exs=""https://extendedxmlserializer.github.io/v2"" exs:arguments=""sys:string,sys:string"" xmlns=""clr-namespace:System.Collections.Immutable;assembly=System.Collections.Immutable""><sys:Item Key=""First"" Value=""Value1"" /><sys:Item Key=""Hello"" Value=""World"" /><sys:Item Key=""Last"" Value=""Value2"" /><sys:Item Key=""Second"" Value=""Value2"" /></ImmutableSortedDictionary>");

			var dictionary = serializer.Cycle(instance);
			dictionary.Should().BeEquivalentTo(instance);

			dictionary["Hello"].Should().Be(instance["Hello"]);
		}

		[Fact]
		public void VerifyWithPropertyAssignments()
		{
			var instance = new[] { 1, 2, 3, 4 }.ToImmutableList();

			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContentWithPropertyAssignments()
			                                             .Create()
			                                             .ForTesting();
			serializer.Assert(instance,
			                  @"<?xml version=""1.0"" encoding=""utf-8""?><ImmutableList xmlns:sys=""https://extendedxmlserializer.github.io/system"" xmlns:exs=""https://extendedxmlserializer.github.io/v2"" exs:arguments=""sys:int"" xmlns=""clr-namespace:System.Collections.Immutable;assembly=System.Collections.Immutable""><sys:int>1</sys:int><sys:int>2</sys:int><sys:int>3</sys:int><sys:int>4</sys:int></ImmutableList>");
			serializer.Cycle(instance).Should().BeEquivalentTo(instance);
		}

		[Fact]
		public void VerifyHashSetWithPropertyAssignments()
		{
			var instance = new[] { 1, 2, 3, 4 }.ToImmutableHashSet();

			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContentWithPropertyAssignments()
			                                             .Create()
			                                             .ForTesting();
			serializer.Assert(instance,
			                  @"<?xml version=""1.0"" encoding=""utf-8""?><ImmutableHashSet xmlns:sys=""https://extendedxmlserializer.github.io/system"" xmlns:exs=""https://extendedxmlserializer.github.io/v2"" exs:arguments=""sys:int"" xmlns=""clr-namespace:System.Collections.Immutable;assembly=System.Collections.Immutable""><sys:int>1</sys:int><sys:int>2</sys:int><sys:int>3</sys:int><sys:int>4</sys:int></ImmutableHashSet>");
			serializer.Cycle(instance).Should().BeEquivalentTo(instance);
		}

		[Fact]
		public void VerifySortedSetWithPropertyAssignments()
		{
			var instance = new[] { 1, 2, 3, 4 }.ToImmutableSortedSet();

			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContentWithPropertyAssignments()
			                                             .Create()
			                                             .ForTesting();
			serializer.Assert(instance,
			                  @"<?xml version=""1.0"" encoding=""utf-8""?><ImmutableSortedSet xmlns:sys=""https://extendedxmlserializer.github.io/system"" xmlns:exs=""https://extendedxmlserializer.github.io/v2"" exs:arguments=""sys:int"" xmlns=""clr-namespace:System.Collections.Immutable;assembly=System.Collections.Immutable""><sys:int>1</sys:int><sys:int>2</sys:int><sys:int>3</sys:int><sys:int>4</sys:int></ImmutableSortedSet>");
			serializer.Cycle(instance).Should().BeEquivalentTo(instance);
		}

		[Fact]
		public void VerifyDictionaryWithPropertyAssignments()
		{
			var instance = new Dictionary<string, string>
			{
				["Hello"] = "World"
			}.ToImmutableDictionary();

			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContentWithPropertyAssignments()
			                                             .Create()
			                                             .ForTesting();

			serializer.Assert(instance,
			                  @"<?xml version=""1.0"" encoding=""utf-8""?><ImmutableDictionary xmlns:sys=""https://extendedxmlserializer.github.io/system"" xmlns:exs=""https://extendedxmlserializer.github.io/v2"" exs:arguments=""sys:string,sys:string"" xmlns=""clr-namespace:System.Collections.Immutable;assembly=System.Collections.Immutable""><sys:Item Key=""Hello"" Value=""World"" /></ImmutableDictionary>");

			var dictionary = serializer.Cycle(instance);
			dictionary.Should().BeEquivalentTo(instance);

			dictionary["Hello"].Should().Be(instance["Hello"]);
		}

		[Fact]
		public void VerifySortedDictionaryWithPropertyAssignments()
		{
			var instance = new Dictionary<string, string>
			{
				["First"]  = "Value1",
				["Hello"]  = "World",
				["Second"] = "Value2",
				["Last"]   = "Value2",
			}.ToImmutableSortedDictionary();

			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContentWithPropertyAssignments()
			                                             .Create()
			                                             .ForTesting();

			serializer.Assert(instance,
			                  @"<?xml version=""1.0"" encoding=""utf-8""?><ImmutableSortedDictionary xmlns:sys=""https://extendedxmlserializer.github.io/system"" xmlns:exs=""https://extendedxmlserializer.github.io/v2"" exs:arguments=""sys:string,sys:string"" xmlns=""clr-namespace:System.Collections.Immutable;assembly=System.Collections.Immutable""><sys:Item Key=""First"" Value=""Value1"" /><sys:Item Key=""Hello"" Value=""World"" /><sys:Item Key=""Last"" Value=""Value2"" /><sys:Item Key=""Second"" Value=""Value2"" /></ImmutableSortedDictionary>");

			var dictionary = serializer.Cycle(instance);
			dictionary.Should().BeEquivalentTo(instance);

			dictionary["Hello"].Should().Be(instance["Hello"]);
		}

		[Fact]
		public void VerifyListEmpty()
		{
			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContent()
			                                             .Create()
			                                             .ForTesting();
			var instance = new SubjectList("Hello World!", ImmutableList<TimeSpan>.Empty);

			serializer.Cycle(instance).Should().BeEquivalentTo(instance);
		}

		[Fact]
		public void VerifyHashSetEmpty()
		{
			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContent()
			                                             .Create()
			                                             .ForTesting();
			var instance = new SubjectHashSet("Hello World!", ImmutableHashSet<TimeSpan>.Empty);

			serializer.Cycle(instance).Should().BeEquivalentTo(instance);
		}

		[Fact]
		public void VerifySortedSetEmpty()
		{
			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContent()
			                                             .Create()
			                                             .ForTesting();
			var instance = new SubjectSortedSet("Hello World!", ImmutableSortedSet<TimeSpan>.Empty);

			serializer.Cycle(instance).Should().BeEquivalentTo(instance);
		}

		[Fact]
		public void VerifyDictionaryEmpty()
		{
			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContent()
			                                             .Create()
			                                             .ForTesting();
			var instance = new SubjectDictionary("Hello World!", ImmutableDictionary<string, string>.Empty);

			serializer.Cycle(instance).Should().BeEquivalentTo(instance);
		}

		[Fact]
		public void VerifySortedDictionaryEmpty()
		{
			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContent()
			                                             .Create()
			                                             .ForTesting();
			var instance = new SubjectSortedDictionary("Hello World!", ImmutableSortedDictionary<string, string>.Empty);

			serializer.Cycle(instance).Should().BeEquivalentTo(instance);
		}

		[Fact]
		public void VerifyListEmptyWithPropertyAssignments()
		{
			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContentWithPropertyAssignments()
			                                             .Create()
			                                             .ForTesting();
			var instance = new SubjectList("Hello World!", ImmutableList<TimeSpan>.Empty);

			serializer.Cycle(instance).Should().BeEquivalentTo(instance);
		}

		[Fact]
		public void VerifyHashSetEmptyWithPropertyAssignments()
		{
			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContentWithPropertyAssignments()
			                                             .Create()
			                                             .ForTesting();
			var instance = new SubjectHashSet("Hello World!", ImmutableHashSet<TimeSpan>.Empty);

			serializer.Cycle(instance).Should().BeEquivalentTo(instance);
		}

		[Fact]
		public void VerifySortedSetEmptyWithPropertyAssignments()
		{
			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContentWithPropertyAssignments()
			                                             .Create()
			                                             .ForTesting();
			var instance = new SubjectSortedSet("Hello World!", ImmutableSortedSet<TimeSpan>.Empty);

			serializer.Cycle(instance).Should().BeEquivalentTo(instance);
		}

		[Fact]
		public void VerifyDictionaryEmptyWithPropertyAssignments()
		{
			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContentWithPropertyAssignments()
			                                             .Create()
			                                             .ForTesting();
			var instance = new SubjectDictionary("Hello World!", ImmutableDictionary<string, string>.Empty);

			serializer.Cycle(instance).Should().BeEquivalentTo(instance);
		}

		[Fact]
		public void VerifySortedDictionaryEmptyWithPropertyAssignments()
		{
			var serializer = new ConfigurationContainer().UseAutoFormatting()
			                                             .UseOptimizedNamespaces()
			                                             .EnableImmutableTypes()
			                                             .EnableParameterizedContentWithPropertyAssignments()
			                                             .Create()
			                                             .ForTesting();
			var instance = new SubjectSortedDictionary("Hello World!", ImmutableSortedDictionary<string, string>.Empty);

			serializer.Cycle(instance).Should().BeEquivalentTo(instance);
		}

		class SubjectList
		{
			public SubjectList(string name, ImmutableList<TimeSpan> list)
			{
				Name = name;
				List = list;
			}

			public string Name { get; }

			public ImmutableList<TimeSpan> List { get; }
		}

		class SubjectHashSet
		{
			public SubjectHashSet(string name, ImmutableHashSet<TimeSpan> list)
			{
				Name = name;
				List = list;
			}

			public string Name { get; }

			public ImmutableHashSet<TimeSpan> List { get; }
		}

		class SubjectSortedSet
		{
			public SubjectSortedSet(string name, ImmutableSortedSet<TimeSpan> list)
			{
				Name = name;
				List = list;
			}

			public string Name { get; }

			public ImmutableSortedSet<TimeSpan> List { get; }
		}

		class SubjectDictionary
		{
			public SubjectDictionary(string name, ImmutableDictionary<string, string> list)
			{
				Name = name;
				List = list;
			}

			public string Name { get; }

			public ImmutableDictionary<string, string> List { get; }
		}

		class SubjectSortedDictionary
		{
			public SubjectSortedDictionary(string name, ImmutableSortedDictionary<string, string> list)
			{
				Name = name;
				List = list;
			}

			public string Name { get; }

			public ImmutableSortedDictionary<string, string> List { get; }
		}
	}
}