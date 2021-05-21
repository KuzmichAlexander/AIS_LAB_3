const fs = require('fs')
const ws = require('ws')
const pathToCBR = "server-2/server-2/Text.txt"


const wss = new ws.Server({
    port: 777
}, () => console.log('ws server started'))

wss.on('connection', (ws) => {
    console.log('кто-то подключился')
})

setInterval(() => {
    if(fs.existsSync(pathToCBR)) {
        fs.readFile(pathToCBR, "utf8",
            function(error,data){
                if(error) console.log('файла нет'); // если возникла ошибка

                wss.clients.forEach(client => {
                    client.send(JSON.stringify(data))
                })
                console.log(data)
                fs.unlinkSync(pathToCBR)
            });
    } else {
        console.log('нету')
    }
}, 3000)
