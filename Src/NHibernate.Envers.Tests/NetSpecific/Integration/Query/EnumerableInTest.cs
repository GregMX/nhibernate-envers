﻿using System.Collections.Generic;
using System.Collections.Specialized;
using System.Xml.Schema;
using NHibernate.Envers.Query;
using NUnit.Framework;
using SharpTestsEx;

namespace NHibernate.Envers.Tests.NetSpecific.Integration.Query
{
	[TestFixture]
	public class EnumerableInTest : TestBase
	{
		protected override void Initialize()
		{
			var entity = new Person {Weight = new Weight{Kilo=75}};
			using (var tx = Session.BeginTransaction())
			{
				Session.Save(entity);
				tx.Commit();
			}
		}

		[Test]
		public void ShouldGiveHit()
		{
			var searchedInts = new []{3, 75, 125};
			Session.Auditer().CreateQuery().ForEntitiesAtRevision<Person>(1)
				.Add(AuditEntity.Property("Weight.Kilo").In(searchedInts))
				.Results().Should().Not.Be.Empty();
		}

		[Test]
		public void ShouldNotGiveHit()
		{
			var searchedInts = new[] { 3, 85, 125 };
			Session.Auditer().CreateQuery().ForEntitiesAtRevision<Person>(1)
				.Add(AuditEntity.Property("Weight.Kilo").In(searchedInts))
				.Results().Should().Be.Empty();			
		}

		[Test]
		public void ShouldWorkUsingObjectArrayDirectly()
		{
			var searchedInts = new object[] { 75 };
			Session.Auditer().CreateQuery().ForEntitiesAtRevision<Person>(1)
				.Add(AuditEntity.Property("Weight.Kilo").In(searchedInts))
				.Results().Should().Not.Be.Empty();
		}

		[Test]
		public void ShouldAcceptEmpty()
		{
			Session.Auditer().CreateQuery().ForEntitiesAtRevision<Person>(1)
				.Add(AuditEntity.Property("Weight.Kilo").In(new List<int>()))
				.Results().Should().Be.Empty();

			Session.Auditer().CreateQuery().ForEntitiesAtRevision<Person>(1)
				.Add(AuditEntity.Property("Weight.Kilo").In(new object[0]))
				.Results().Should().Be.Empty();
		}
	}
}