# ShoppingCart

**Api in c# to buy pre-loade products**, and show in console a log whith the operations makes by the user

### Functionalities:

1. Get products available

2. Get product by code

3. Get bill by userid

4. Buy products

### Running Docker

Build your local image by running:

```
docker build -t shoppingcart-image -f ShoppingCart/Dockerfile .
docker images
```

Run the container:

```
docker run --name shoppingcart -it -d -p 127.0.0.1:3025:80 shoppingcart-image
docker ps
```

View console:

```
docker logs -f shoppingcart
```

## Access through your browser

Acces to sagger to test de aplication

```
127.0.0.1:3025/swagger
```