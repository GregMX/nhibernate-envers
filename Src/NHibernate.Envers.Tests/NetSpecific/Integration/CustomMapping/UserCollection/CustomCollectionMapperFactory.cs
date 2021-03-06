﻿using NHibernate.Envers.Entities.Mapper;
using NHibernate.Envers.Entities.Mapper.Relation;

namespace NHibernate.Envers.Tests.NetSpecific.Integration.CustomMapping.UserCollection
{
	public class CustomCollectionMapperFactory : ICustomCollectionMapperFactory
	{
		public IPropertyMapper Create(CommonCollectionMapperData commonCollectionMapperData, MiddleComponentData elementComponentData, MiddleComponentData indexComponentDatabool, bool embeddableElementType)
		{
			return new SpecialMapper(commonCollectionMapperData, elementComponentData, embeddableElementType);
		}
	}
}