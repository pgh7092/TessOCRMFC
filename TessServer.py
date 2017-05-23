import socket
import os
import io
import os.path
import tesserocr
import time
from PIL import Image

def Main():
	s = socket.socket()
	host = ''
	port = 5007
	sum = 0
	s.bind((host, port))

	s.listen(1)
	print("Waiting for a connection...")

	c, addr = s.accept()
	print("Connection from: " + str(addr))

	if os.path.isfile("image.png"):
        	os.remove("image.png")

	file = open("image.png", "w+b")
	while True:
        	data = c.recv(1024)
		if not data:
			break
		file.write(data)

	print tesserocr.file_to_text('image.png')

	print("Done.")
	c.close()
	s.close()

if __name__ == "__main__":
	Main()
