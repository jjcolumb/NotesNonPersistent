using System;
using DevExpress.ExpressApp.Xpo;

namespace NotesNonPersistent.Blazor.Server.Services {
    public class XpoDataStoreProviderAccessor {
        public IXpoDataStoreProvider DataStoreProvider { get; set; }
    }
}
