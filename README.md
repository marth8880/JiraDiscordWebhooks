# JIRA Discord Webhook Integration

Based on http://www.pleasebepatientlabs.com/2017/04/03/create-discord-bot-using-webhooks/

This is an application that sends JIRA notifications to Discord channels. It is written in C# for .NET Framework 4.6.1.

As with most lightweight Discord integrations, this utilizes webhooks to HTTP GET json data from JIRA whenever an issue is created/updated/etc., deserialize and reformat the data into something edible by Discord, and HTTP POST it to a Discord channel.

The code I forked it from was sort of broken-ish; the json data structures were a bit outdated (using key/value pairs from old APIs), so I ended up having to update each; and plus it was originally created as a C# console application but I don't want to have a command prompt perpetually open on my PC, so I ported it to a forms application.
