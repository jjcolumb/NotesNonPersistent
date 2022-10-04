using System;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace NotesNonPersistent.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Notes : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public Notes(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        string _text;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Text
        {
            get => _text;
            set => SetPropertyValue(nameof(Text), ref _text, value);
        }

        DateTime _dateCreated;
        public DateTime DateCreated
        {
            get => _dateCreated;
            set => SetPropertyValue(nameof(DateCreated), ref _dateCreated, value);
        }

        ApplicationUser _user;
        public ApplicationUser User
        {
            get => _user;
            set => SetPropertyValue(nameof(User), ref _user, value);
        }

        Master _master;
        [Association("Master-Notes")]
        public Master Master
        {
            get => _master;
            set => SetPropertyValue(nameof(Master), ref _master, value);
        }

    }
}