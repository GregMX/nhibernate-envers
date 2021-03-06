﻿using NHibernate.Envers.Configuration.Attributes;

namespace NHibernate.Envers.Tests.Integration.Interfaces.Inheritance.PropertiesAudited2
{
	public interface ISimple
	{
		long Id { get; set; }
		[Audited]
		string Data { get; set; }
		[Audited]
		int Number { get; set; }
	}
}