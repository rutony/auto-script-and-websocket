const WebSocket = require('ws');

function send(action, num)
{
  if (ws == null) return;
  if (!action) return;

  ws.send(action + '_' + num);
}

const ws = new WebSocket('ws://127.0.0.1:5157/');

ws.on('open', function open() {
  send('hello', 0);
  send('again', 3);
  send('and_again', 4);
  send('and_again_and_again', 10);
});

ws.on('message', function message(data) {
  console.log('received: %s', data);
});