#!/bin/env python
import random
import os
import sys
import subprocess
import itertools

def randchars(len):
	min = 31 # start at 32, but pretend 31 is tab
	max = 126
	rv = ""
	for i in xrange(0, len):
		byte = random.randrange(min, max)
		if byte == 31: byte = 11
		rv += chr(byte)
	return rv

here = os.path.dirname(__file__)
exe = [os.path.join(here, 'execv.exe')]
if not sys.platform.startswith('win'):
	exe.insert(0, 'mono')

def test(argv):
	print ""
	expected = repr(args)
	print repr(args)
	full_args = ["python", "-c", "import sys; print repr(sys.argv[1:])"] + args
	out = subprocess.check_output(exe + full_args).rstrip("\r\n")
	if out != expected:
		print out
		for i, (a, b) in enumerate(itertools.izip_longest(out, expected)):
			if a != b:
				print (" " * i) + "^"
				break
		sys.exit(1)

if __name__ == '__main__':
	args = sys.argv[1:]
	if args:
		# specific args
		test(args)
	else:
		# fuzz test
		while True:
			args = []
			for i in xrange(0, random.randrange(0, 10)):
				args.append(randchars(random.randrange(0, 20)))
			test(args)
	

