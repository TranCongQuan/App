var Discord = require('discord.io');
var logger = require('winston');
var auth = require('./auth.json');

//Configure logger settings.
logger.remove(logger.transports.Console);
logger.add(logger.transports.Console, {
    colorize:true
});

logger.level = 'debug';

//Initialize the bot
var bot = new Discord.Client({
    token: auth.token,
    autorun:true
});

bot.on('ready', function(evt){
    logger.info('Connected');
    logger.info('Logged in as: ');
    logger.info(bot.username + ' - (' + bot.id + ')');
});

bot.on('message', function(user, userID, channelID, message, evt){
    //Bot needs to know if it will execute a command.
    //Bot will listen for messages that start with an '!'.
    if(message.substring(0, 1) == '!'){
        var args = message.substring(1).split(' ');
        var cmd = args[0];

        args = args.splice(1);
        switch(cmd){
            //!ping
            case 'ping':
                bot.sendMessage({
                    to: channelID,
                    message: "Hi, this is the tutorial bot!\nUse the command !tutcommands for all my commands!"
                });
            break;
            //!tutcommands
            case 'tutcommands':
                bot.sendMessage({
                    to: channelID,
                    message: "My commands are:\n!ping\n!tutcommands\n!talk\n!yell\n!calm"
                });
            break;
            //!talk
            case 'talk':
                bot.sendMessage({
                    to: channelID,
                    message: "Look at me! I'm talking!"
                });
            break;
            //!yell
            case 'yell':
                bot.sendMessage({
                    to: channelID,
                    message: "I'M YELLING OKAY!!"
                });
            break;
            //!calm
            case 'calm':
                bot.sendMessage({
                        to: channelID,
                        message: "Calm down, everything is going to be okay."
                });
            break;
        }
    }
});
