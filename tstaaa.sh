#!/bin/bash
set -e -x
TAG=`git describe --tags | sed s/^v/:/`;
REGISTRY=abcd.com;
JOB_NAME=test;

# Build sources and run unit tests
docker -f docker.ci.build.yml -p $JOB_NAME run --rm -T ci-build
docker -f docker.ci.build.yml -p $JOB_NAME down

# Build images
docker -f docker.yml -p $JOB_NAME build --pull

docker login -u testuser -p abcd@333 $REGISTRY

#Push curreng tag
docker -f docker.yml push

#Tag as latest and push
images=$(docker -f docker.yml config | grep -o "$REGISTRY.*")
for image in $images; do
        base=$(echo $image | cut -d ":" -f 1)
        echo "base=$base";
        repo=$(echo $base | cut -d "/" -f 2-)
        echo "repo=$repo";
        newtag="${REGISTRY}/$repo:latest"
        echo "Tagging $image -> $newtag"
        docker tag $image $newtag
done
TAG=:latest
docker -f docker.yml push

export DEPLOY_ENVIRONMENT=$1;
stackname=$(git remote get-url origin | sed 's/.*[\/_]//; s/\.git$//');
echo "Deploying $stackname stack to $DEPLOY_ENVIRONMENT";
docker stack deploy -c docker.yml --with-registry-auth $stackname;
