from flask import Flask, escape, request

app = Flask(__name__)

@app.route('/')
#def hello():
#    name = request.args.get("name", "World")
#    return f'Hellom {escape(name)}!'

def hello_world():
    return 'Hello, World!'
