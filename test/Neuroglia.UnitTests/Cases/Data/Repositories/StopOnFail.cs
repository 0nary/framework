using System.Collections.Generic;

namespace Neuroglia.UnitTests.Cases.Data.Repositories
{

	public class StopOnFail
	{
		static private bool _HasFail = false;

		static public bool HasFail
		{
			get { return _HasFail; }
			set { _HasFail = value; }
		}


	}

}
