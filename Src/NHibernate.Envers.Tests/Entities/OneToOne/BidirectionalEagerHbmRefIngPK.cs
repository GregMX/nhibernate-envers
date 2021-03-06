using NHibernate.Envers.Configuration.Attributes;

namespace NHibernate.Envers.Tests.Entities.OneToOne
{
	[Audited]
	public class BidirectionalEagerHbmRefIngPK
	{
		public virtual long Id { get; set; }
		public virtual string Data { get; set; }
		public virtual BidirectionalEagerHbmRefEdPK Reference { get; set; }

		public override bool Equals(object obj)
		{
			var that = obj as BidirectionalEagerHbmRefIngPK;
			if (that == null)
				return false;
			if (Id != that.Id) return false;
			if (Data != null ? !Data.Equals(that.Data) : that.Data != null) return false;
			return true;
		}

		public override int GetHashCode()
		{
			var result = Id.GetHashCode();
			result = 31 * result + (Data != null ? Data.GetHashCode() : 0);
			return result;
		}
	}
}