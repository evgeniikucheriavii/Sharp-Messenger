﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerApp
{
	class Messenger
	{
		private string login = "admin";
		private string password = "12345";

		private List<User> users;
		private List<Message> messages;

		private List<Message> chat;

		private List<Contact> contacts;
		private Contact currentContact;

		private User user;

		public Messenger()
		{
			users = new List<User>();
			contacts = new List<Contact>();
			messages = new List<Message>();
		}

		public Messenger(List<Contact> contacts, List<Message> messages, List<User> users)
		{
			this.users = users;
			this.contacts = contacts;
			this.messages = messages;
		}

		public void LoadChat()
		{

		}

		public bool Login(string login, string password)
		{
			if (this.login == login && this.password == password)
			{
				LoadUsers();
				LoadMessages();
				user = users[0];

				GetContacts();

				
				return true;
			}
			else
			{
				return false;
			}
		}

		private void LoadUsers()
		{
			users.Add(new User(1, "Evgenii", ""));
			users.Add(new User(2, "Ivan", ""));
			users.Add(new User(3, "John", ""));
			users.Add(new User(4, "Boris", ""));
			users.Add(new User(5, "Igor", ""));
		}

		private void LoadMessages()
		{
			//Contact 1
			messages.Add(new Message("Hello!", users[0], users[1]));
			messages.Add(new Message("Hello.", users[1], users[0]));
			messages.Add(new Message("How are you?", users[0], users[1]));
			messages.Add(new Message("Fine.", users[1], users[0]));
			messages.Add(new Message("Are you okay?", users[0], users[1]));
			messages.Add(new Message("Yes.", users[1], users[0]));
			messages.Add(new Message("If you say so...", users[0], users[1]));
			messages.Add(new Message("Ah! You don't care about me!", users[1], users[0]));
			messages.Add(new Message("...", users[0], users[1]));

			//Contact 2
			messages.Add(new Message("Hello!", users[0], users[2]));
			messages.Add(new Message("Hello!", users[2], users[0]));
		}

		private void GetContacts()
		{
			foreach(Message message in messages)
			{
				bool getContact = false;
				foreach (Contact contact in contacts)
				{
					if (contact.Confirm(message.Sender, message.Reciever))
					{
						getContact = true;
						break;
					}
				}

				if(!getContact)
				{
					contacts.Add(new Contact(message.Sender, message.Reciever, user.ID));
				}
			}
		}

		public void ChangeContact(int index)
		{
			this.currentContact = this.contacts[index];
		}

		public User User
		{
			get
			{
				return this.user;
			}
		}

		public List<Contact> Contacts
		{
			get
			{
				return this.contacts;
			}
		}

		public Contact CurrentContact
		{
			get
			{
				return this.currentContact;
			}
		}

		public List<Message> Messages
		{
			get
			{
				return this.messages;
			}
		}

		public List<Message> Chat
		{
			get
			{
				return this.chat;
			}
		}
	}
}