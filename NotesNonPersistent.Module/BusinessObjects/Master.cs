using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NotesNonPersistent.Module.BusinessObjects
{
    [DefaultClassOptions]   
    public class Master : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Master(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string _name;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => _name;
            set => SetPropertyValue(nameof(Name), ref _name, value);
        }

        bool _activo;
        public bool Activo
        {
            get => _activo;
            set => SetPropertyValue(nameof(Activo), ref _activo, value);
        }

        string _notesNonPersistent;
        [Size(SizeAttribute.Unlimited)]
        [NonPersistent]
        public string NotesNonPersistent
        {
            get => _notesNonPersistent;
            set => SetPropertyValue(nameof(NotesNonPersistent), ref _notesNonPersistent, value);
        }

        [Association("Master-Notes")]
        public XPCollection<Notes> Notes
        {
            get
            {
                return GetCollection<Notes>(nameof(Notes));
            }
        }


        protected override void OnSaving()
        {
            base.OnSaving();

            if (!String.IsNullOrEmpty(NotesNonPersistent))
            {
                var note = new Notes(Session);
                note.Text = NotesNonPersistent;
                note.DateCreated = DateTime.Now;
                note.User = Session.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
                note.Master = this;
                note.Save();
                NotesNonPersistent = String.Empty;
            }

        }
    }
}